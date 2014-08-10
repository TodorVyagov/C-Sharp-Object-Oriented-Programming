using System;
namespace DocumentSystem
{
    interface IEncryptable
    {
        void Decrypt();
        void Encrypt();
        bool IsEncrypted { get; }
    }
}
