// See https://aka.ms/new-console-template for more information
using XPosConnect.Lib;

var xposConnectServices = new XPosConnectService();
xposConnectServices.GenQrCode(new XPosConnect.Lib.Dto.Sdk.ShowQrDto
{
    Amount = 20000,
    Data = "00020101021238540010A000000727012400069704180110V4HUCE79700208QRIBFTTA53037045405200005802VN62220818Ung Ho Quy Vac Xin6304BA12",
    Note = "Nghia test",
});