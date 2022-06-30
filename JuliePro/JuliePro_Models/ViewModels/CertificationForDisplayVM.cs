using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class CertificationForDisplayVM : BaseEntityForDisplayVM
    {
        public CertificationForDisplayVM() 
            : base()
        { }
        public CertificationForDisplayVM(Certification certification) 
            : base()
        {
            Id = certification.Id;
            Title = certification.Title;
            CertificationCenter = certification.CertificationCenter;
        }

        public string Title { get; set; }
        public string CertificationCenter { get; set; }
    }
}