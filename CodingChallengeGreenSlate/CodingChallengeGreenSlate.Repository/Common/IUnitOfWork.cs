using System;


namespace CodingChallengeGreenSlate.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
