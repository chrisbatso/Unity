﻿using System.Threading.Tasks;
using System;

namespace GitHub.Unity
{
    interface IApiClient
    {
        HostAddress HostAddress { get; }
        UriString OriginalUrl { get; }
        Task CreateRepository(string name, string description, bool isPrivate,
            Action<GitHubRepository, Exception> callback, string organization = null);
        Task GetOrganizations(Action<Organization[]> onSuccess, Action<Exception> onError = null);
        Task Login(string username, string password, Action<LoginResult> need2faCode, Action<bool, string> result);
        Task ContinueLogin(LoginResult loginResult, string code);
        Task<bool> LoginAsync(string username, string password, Func<LoginResult, string> need2faCode);
        Task Logout(UriString host);
        Task ValidateCurrentUser(Action onSuccess, Action<Exception> onError = null);
    }
}
