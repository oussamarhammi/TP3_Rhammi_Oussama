using JuliePro_Utility;
using System.Collections.Generic;

namespace JuliePro_Models.ViewModels
{
    public class GenericControllerDisplayVM<TEntityForDisplayVM> : BaseControllerActionVM where TEntityForDisplayVM : BaseEntityForDisplayVM
    {
        public GenericControllerDisplayVM() 
            : base()
        { }
        public virtual GenericControllerDisplayVM<TEntityForDisplayVM> Init(bool isDetails, string pageTitle, string pageHeading, List<PageLinks> links, TEntityForDisplayVM entity)
        {
            return Init(isDetails, pageTitle, pageHeading, links, null, entity);
        }
        public virtual GenericControllerDisplayVM<TEntityForDisplayVM> Init(bool isDetails, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, TEntityForDisplayVM entity)
        {
            base.Init(pageTitle, pageHeading, links, submitButtonText);
            IsDetails = isDetails;
            Entity = entity;
            Id = entity.Id;
            return this;
        }

        public bool IsDetails { get; set; }
        public int Id { get; set; }
        public TEntityForDisplayVM Entity { get; set; }
    }
}
