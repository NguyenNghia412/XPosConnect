using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPosConnect.Lib.Dto.Sdk
{
    public class ShowQrDto
    {
        public required string Data { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
    }
}
