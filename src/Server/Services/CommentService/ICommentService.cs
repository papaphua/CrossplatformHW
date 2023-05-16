using CrossplatformHW.Server.Data.Entities;

namespace CrossplatformHW.Server.Services.CommentService;

public interface ICommentService
{
    Task<List<Comment>> GetProductCommentsAsync(Guid productId);
    Task<Comment?> GetCommentByIdAsync(Guid id);
}