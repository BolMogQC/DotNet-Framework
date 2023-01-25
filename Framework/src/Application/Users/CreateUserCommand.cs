using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Users;

public class CreateUserCommand : IRequest<string>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IApplicationDbContext context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Email = request.Email,
            Password = string.Empty
            // TODO: Get password and hash it
        };

        context.Users.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}