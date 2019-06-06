using System;


namespace CodingChallengeGreenSlate.Data.Common
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
