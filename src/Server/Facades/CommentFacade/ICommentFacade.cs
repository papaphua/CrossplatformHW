using CrossplatformHW.Server.Primitives;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Pagination.Parameters;

namespace CrossplatformHW.Server.Facades.CommentFacade;

public interface ICommentFacade
{
    Task<PagedList<CommentDto>> GetCommentsForProductByParametersAsync(CommentParameters parameters);
    Task AddCommentAsync(Guid userId, NewCommentDto newCommentDto);
    Task UpdateCommentAsync(Guid userId, CommentDto commentDto);
    Task DeleteCommentAsync(Guid userId, Guid commentId);
}