using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainSorgula.Component
{
    public class MultiThreadedBindList<T> : BindingList<T>
    {
        SynchronizationContext ctx = SynchronizationContext.Current;
        public MultiThreadedBindList() { }
        public MultiThreadedBindList(IList<T> list) : base(list) { }
        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            if (ctx == null)
                BaseAddingNew(e);
            else
                ctx.Post(delegate { BaseAddingNew(e); }, null);
        }

        void BaseAddingNew(AddingNewEventArgs e)
        {
            base.OnAddingNew(e);
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (ctx == null)
                BaseListChanged(e);
            else
                ctx.Post(delegate { BaseListChanged(e); }, null);
        }

        void BaseListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);
        }
    }
}
