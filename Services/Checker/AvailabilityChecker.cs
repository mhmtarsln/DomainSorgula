using DomainSorgula.Settings;
using DomainSorgula.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DomainSorgula.Services.Checker
{
    public static class AvailabilityChecker
    {
        public delegate void StatusChangedHandler(Status status, int index); 

        public static event StatusChangedHandler OnStatusChanged;
        private static List<CheckService> ServiceList { get; set; } = new List<CheckService>();
        static AvailabilityChecker()
        {
            var services = typeof(CheckService).Assembly.GetTypes().Where(x => x.BaseType == typeof(CheckService));
            if (services == null)
                throw new Exception("Domain kontrol servisi bulunamadı!");
            foreach (var service in services)            
                ServiceList.Add(Activator.CreateInstance(service) as CheckService);             
        }
        public static async Task CheckAll(CancellationToken cancel)
        {
            var taskList = new List<Task>();
            using (var semaphore = new SemaphoreSlim(Setting.ConcurrentCount))
            {
                foreach (var domain in CheckService.DomainList)
                {
                    cancel.ThrowIfCancellationRequested();
                    await semaphore.WaitAsync();
                    taskList.Add(Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            cancel.ThrowIfCancellationRequested();
                            if (ServiceList[(domain.Index - 1) % ServiceList.Count].CheckIsAvailable(domain))
                            {
                                domain.Status = "Müsait";
                                OnStatusChanged?.Invoke(Status.Available, domain.Index - 1);
                            }
                            else
                            {
                                domain.Status = "Alınmış";
                                OnStatusChanged?.Invoke(Status.Taken, domain.Index - 1);
                            }
                        }
                        catch (Exception)
                        {
                            domain.Status = "Bağlantı Engellendi!";
                            OnStatusChanged?.Invoke(Status.Blocked, domain.Index - 1);
                        }
                        finally
                        {
                            semaphore.Release();
                        }

                    }, cancel));

                }
                await Task.WhenAll(taskList.ToArray());
            }

        }

    }
}
