using Microsoft.AspNetCore.Mvc;
using Nethereum.Web3;

namespace CryptoTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EthereumNodeController : ControllerBase
    {
        private readonly ILogger<EthereumNodeController> _logger;

        public EthereumNodeController(ILogger<EthereumNodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBalance")]
        public async Task<decimal> GetBalance(string publicAddress)
        {
            var web3 = new Web3("https://mainnet.infura.io/v3/0742d76b3a144bd8a71d25b7fba93981");
            var hexBalance = await web3.Eth.GetBalance.SendRequestAsync(publicAddress);

            return Web3.Convert.FromWei(hexBalance.Value); ;
        }
    }
}