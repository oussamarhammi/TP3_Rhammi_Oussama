using JuliePro_Utility;
using System.Collections.Generic;

namespace JuliePro_Models.ViewModels
{
    public interface IGenericControllerIndexVM<TEntityForListVM> where TEntityForListVM : class
    {
        GenericControllerIndexVM<TEntityForListVM> Init<TEntityForListVMM>(string pageTitle, string pageHeading, List<PageLinks> links, ICollection<TEntityForListVM> collection) where TEntityForListVMM : class;
        GenericControllerIndexVM<TEntityForListVM> Init<TEntityForListVMM>(string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, ICollection<TEntityForListVM> collection) where TEntityForListVMM : TEntityForListVM;
    }
}
