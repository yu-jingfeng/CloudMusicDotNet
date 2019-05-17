﻿using System.Threading.Tasks;

namespace CloudMusicDotNet.Commons.MusicServices
{
    public interface IAlbumService
    {
        Task<string> NewAlubm(string data);

        Task<string> Sublist(string data);

        Task<string> Content(string data, string id);
    }
}