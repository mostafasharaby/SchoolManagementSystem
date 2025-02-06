namespace SchoolManagementSystem.Api.AppRouting
{
    public static class Routing
    {
        public static class StudentRouting
        {
            public const string List = "List";        // Remove "Student/" to avoid duplication
            public const string ById = "{id}";        // Keep only "{id}" for dynamic routing
            public const string Create = "Create";
            public const string Update = "Update/{id}";
            public const string Delete = "Delete/{id}";
        }

        public static class TeacherRouting
        {
            public const string List = "List";
            public const string ById = "{id}";
            public const string Create = "Create";
            public const string Update = "Update/{id}";
            public const string Delete = "Delete/{id}";
        }
    }

}
