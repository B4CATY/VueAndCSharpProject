
using CSharpBackEnd.Models;
using CSharpBackEnd.Models.ResponseModels;
using ParcerLibrarry;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBackEnd.Services
{
    public interface IParcerXmlService
    {
        Task<List<LinkTime>> ParceAsync(string url);
        Task<bool> CreateAsync(string url, List<LinkTime> linkTimes);
        IQueryable<LinkResponseModel> GetLinks();
        /*Task<List<ParcedLink>> GetByIdAsync(PaginationDTO model);*/
        IQueryable<ParcedLink> GetParcedLinksById(int id);
    }
}
