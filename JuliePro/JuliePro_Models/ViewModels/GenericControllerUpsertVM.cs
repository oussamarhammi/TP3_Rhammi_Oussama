using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace JuliePro_Models.ViewModels
{
    public class GenericControllerUpsertVM<TEntity> : BaseControllerActionVM where TEntity : class
    {
        public GenericControllerUpsertVM() 
            : base()
        { }
        public virtual GenericControllerUpsertVM<TEntity> Init(bool isCreate, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, Dictionary<string, SelectList­> selectLists)
        {
            return Init(isCreate, pageTitle, pageHeading, links, submitButtonText, selectLists, null, 0);
        }
        public virtual GenericControllerUpsertVM<TEntity> Init(bool isCreate, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, Dictionary<string, SelectList­> selectLists, TEntity entity, int? entityId)
        {
            base.Init(pageTitle, pageHeading, links, submitButtonText);
            IsCreate = isCreate;
            Entity = entity;
            Id = entityId;
            SelectLists = selectLists;
            return this;
        }

        public bool IsCreate { get; set; }
        public int? Id { get; set; }
        public TEntity Entity { get; set; }
        public Dictionary<string, SelectList­> SelectLists { get; set; }
    }
}
