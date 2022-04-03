using System.Collections.Generic;
using System.Threading.Tasks;
using WebBetardQRCodeLib.Models;

namespace WebBetardQRCodeLib.DataAccess
{
    public interface IDrawingStatusTypeData
    {
        Task CreateDrawingStatusType(DrawingStatusTypeModel drawingStatusType);
        Task<List<DrawingStatusTypeModel>> GetAllDrawingStatusTypes();
        Task<DrawingStatusTypeModel> GetDrawingStatusId(string text);
        Task<DrawingStatusTypeModel> GetDrawingStatusType(string id);
    }
}