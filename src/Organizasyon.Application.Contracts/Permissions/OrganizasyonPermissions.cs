namespace Organizasyon.Permissions
{
    public static class OrganizasyonPermissions
    {
        public const string GroupName = "Organizasyon";
        public const string Identity = "AbpIdentity";

        public static class Users
        {
            public const string Default = Identity + ".Users";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string ManagePermission = Default + ".ManagePermissions";
        }
        public static class Roles
        {
            public const string Default = Identity + ".Roles";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
            public const string ManagePermission = Default + ".ManagePermissions";
        }

        public static class Companies
        {
            public const string Default = GroupName + ".Companies";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Labels
        {
            public const string Default = GroupName + ".Labels";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class FrequentlyAskedQuestions
        {
            public const string Default = GroupName + ".FrequentlyAskedQuestions";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Packages
        {
            public const string Default = GroupName + ".Packages";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

    }
}