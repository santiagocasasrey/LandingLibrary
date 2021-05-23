namespace LandingLibrary.Enums
{
    public enum LandingPlatformResultEnum
    {
        OkLanding,
        OutPlatform,
        Clash
    }

    public static class LandingPlatformResults {
        public static string GetResultsString(LandingPlatformResultEnum landingPlatformResult)
        {
            string result = "";
            switch (landingPlatformResult)
            {
                case LandingPlatformResultEnum.OkLanding:
                    {
                        result = "ok for landing";
                        break;
                    }
                case LandingPlatformResultEnum.OutPlatform:
                    {
                        result = "out of platform";
                        break;
                    }
                case LandingPlatformResultEnum.Clash:
                    {
                        result = "clash";
                        break;
                    }
            }
            return result;
        }
    }
}
