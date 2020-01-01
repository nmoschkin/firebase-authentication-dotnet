﻿namespace Firebase.Auth.Providers
{
    public class FacebookProvider : OAuthProvider
    {
        public const string DefaultEmailScope = "email";

        public FacebookProvider()
        {
            this.AddScopes(DefaultEmailScope);
        }

        public override FirebaseProviderType ProviderType => FirebaseProviderType.Facebook;
    }
}
