using System;

namespace CloudMusicDotNet.Commons
{
    public interface ICryptoService
    {
        string GetWeapiCrypto(string data);

        string GetLinuxapiCrypto(string data);
    }
}
