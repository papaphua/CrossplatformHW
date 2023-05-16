using CrossplatformHW.Client.Models.Pagination;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Pagination.Parameters;

namespace CrossplatformHW.Client.Services.CommentService;

public interface ICommentService
{
    Task<PagingResponse<CommentDto>> GetComments(CommentParameters parameters);
    Task AddComment(NewCommentDto newCommentDto);
    Task UpdateComment(CommentDto commentDto);
    Task DeleteComment(Guid commentId);
}