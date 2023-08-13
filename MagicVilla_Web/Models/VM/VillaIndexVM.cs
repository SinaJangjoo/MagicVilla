using MagicVilla_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MagicVilla_Web.Models.VM
{
	public class VillaIndexVM
	{
        public VillaIndexVM()
        {
            Villas = new List<VillaDTO>();
        }
        public List<VillaDTO> Villas { get; set; }
        [ValidateNever]
        public PaginationDTO pagination { get; set; }
    }
}
