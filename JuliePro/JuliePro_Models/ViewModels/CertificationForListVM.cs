using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class CertificationForListVM
    {
        public CertificationForListVM()
        { }
        public CertificationForListVM(Certification certification)
        {
            Id = certification.Id;
            Title = certification.Title;
            CertificationCenter = certification.CertificationCenter;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string CertificationCenter { get; set; }
    }
}