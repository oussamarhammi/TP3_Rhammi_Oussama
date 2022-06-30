using JuliePro_Utility;
using System.Collections.Generic;

namespace JuliePro_Models.ViewModels
{
    public class GenericControllerIndexVM<TEntityForListVM> : BaseControllerActionVM where TEntityForListVM : class
    {
        public GenericControllerIndexVM() : base()
        { }
        public virtual GenericControllerIndexVM<TEntityForListVM> Init<TEntityForListVMM>(string pageTitle, string pageHeading, List<PageLinks> links, ICollection<TEntityForListVM> collection) where TEntityForListVMM : class
        {
            return Init<TEntityForListVM>(pageTitle, pageHeading, links, null, collection);
        }
        public virtual GenericControllerIndexVM<TEntityForListVM> Init<TEntityForListVMM>(string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, ICollection<TEntityForListVM> collection) where TEntityForListVMM : TEntityForListVM
        {
            base.Init(pageTitle, pageHeading, links);
            Collection = (ICollection<TEntityForListVM>)collection;
            return this;
        }

        public int? Id { get; set; }
        public ICollection<TEntityForListVM> Collection { get; set; }
    }
}
