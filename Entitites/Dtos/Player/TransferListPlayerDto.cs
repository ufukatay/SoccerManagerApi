using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dtos.Player
{
    public class TransferListPlayerDto
    {
        public bool isIntransferList { get; set; } = false;
        public int marketValue { get; set; }
    }
}
