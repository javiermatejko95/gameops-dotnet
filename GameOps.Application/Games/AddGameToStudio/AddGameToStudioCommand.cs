namespace GameOps.Application.Games.CreateGame
{
    public record AddGameToStudioCommand(Guid StudioId, string Name);
}
