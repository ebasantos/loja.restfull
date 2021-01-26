using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Shared.Repository
{
    public interface IConnection
    {
        void AbrirTransacao();
        void Commit();
        void RollBack();
    }
}
