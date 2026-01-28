namespace GameOps.Application.Games.CreateGame
{
    public record AddGameToStudioCommand(Guid StudioId, Guid GameId, string Name);
}
