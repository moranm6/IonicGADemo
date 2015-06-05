namespace ScoreboardServer.Services
{
    public interface IVotePersister
    {
        void PersistVote(string name);
        int GetCountBy(string name);
    }
}