using Carros.Compra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Compra.Domain.Interfaces
{
    public interface IMensagemRepository
    {
        void EnviarMensagem(MensagemCarro mensagem, string fila);
    }
}
