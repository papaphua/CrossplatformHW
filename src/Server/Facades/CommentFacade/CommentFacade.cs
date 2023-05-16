using AutoMapper;
using CrossplatformHW.Server.Common;
using CrossplatformHW.Server.Common.Exceptions;
using CrossplatformHW.Server.Data;
using CrossplatformHW.Server.Data.Entities;
using CrossplatformHW.Server.Primitives;
using CrossplatformHW.Server.Services.CommentService;
using CrossplatformHW.Server.Services.ProductService;
using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Pagination.Parameters;

namespace CrossplatformHW.Server.Facades.CommentFacade;

public sealed class CommentFacade : ICommentFacade
{
    private readonly ICommentService _commentService;
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public CommentFacade(ICommentService commentService, IMapper mapper, AppDbContext db,
        IProductService productService)
    {
        _commentService = commentService;
        _mapper = mapper;
        _db = db;
        _productService = productService;
    }

    public async Task<PagedList<CommentDto>> GetCommentsForProductByParametersAsync(CommentParameters parameters)
    {
        var comments = await _commentService.GetProductCommentsAsync(parameters.ProductId);

        var dtos = comments
            .Select(comment => _mapper.Map<CommentDto>(comment))
            .ToList();

        return PagedList<CommentDto>
            .ToPagedList(dtos, parameters.PageNumber, parameters.PageSize);
    }

    public async Task AddCommentAsync(Guid userId, NewCommentDto newCommentDto)
    {
        var product = await _productService.GetProductByIdAsync(newCommentDto.ProductId);

        if (product is null) throw new NotFoundException(ExceptionMessages.ProductNotFound);
        
        var comment = new Comment { Text = newCommentDto.Text, UserId = userId, Product = product};
        
        await _db.Comments.AddAsync(comment);

        await _db.SaveChangesAsync();
    }


    public async Task UpdateCommentAsync(Guid userId, CommentDto commentDto)
    {
        var comment = await _commentService.GetCommentByIdAsync(commentDto.Id);

        if (comment is null) throw new NotFoundException(ExceptionMessages.CommentNotFound);

        if (comment.UserId != userId) throw new BusinessException(ExceptionMessages.Unauthorized);

        comment.Text = commentDto.Text;

        await _db.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(Guid userId, Guid commentId)
    {
        var comment = await _commentService.GetCommentByIdAsync(commentId);

        if (comment is null) throw new NotFoundException(ExceptionMessages.CommentNotFound);

        if (comment.UserId != userId) throw new BusinessException(ExceptionMessages.Unauthorized);

        _db.Comments.Remove(comment);
        await _db.SaveChangesAsync();
    }
}