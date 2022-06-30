using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace JuliePro_Models.ViewModels
{
    public class BaseControllerActionVM
    {
        public BaseControllerActionVM()
        { }
        public virtual BaseControllerActionVM Init(string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText = null)
        {
            GeneralViewInfos = new GeneralViewInfosVM(pageTitle, pageHeading, links, submitButtonText);
            return this;
        }
        public virtual BaseControllerActionVM Init(string pageTitle, string pageHeading, List<PageLinks> links) => Init(pageTitle, pageHeading, links, null);
        public virtual BaseControllerActionVM Init(string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, object data = null) => Init(pageTitle, pageHeading, links, submitButtonText);
        public virtual BaseControllerActionVM Init(bool isAction, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, object data = null) => Init(pageTitle, pageHeading, links, submitButtonText);
        public virtual BaseControllerActionVM Init(bool isAction, string pageTitle, string pageHeading, List<PageLinks> links, string submitButtonText, Dictionary<string, SelectList­> selectLists, object entity, int? entityId) => Init(pageTitle, pageHeading, links, submitButtonText);
        public GeneralViewInfosVM GeneralViewInfos { get; set; }
    }
}
