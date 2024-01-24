namespace EFUsage.Common
{
    public static class CustomContainer
    {
        private static readonly Dictionary<dynamic, dynamic> container = [];

        public static void AddContainerV2<IType, CType>()
            where IType : notnull
            where CType : IType, new()
        {
            if (!container.ContainsKey(typeof(IType)))
                container.Add(typeof(IType), new CType());
        }

        public static dynamic GetItemV2<T>() => container[typeof(T)];



        private static List<dynamic> items = [];

        public static void AddContainer<IType, CType>()
            where IType : notnull
            where CType : IType, new()
        {
            items.Add(new CustomContainerItem<IType, CType>());
        }

        public static T? GetItem<T>()
        {
            return items.Where(item => item.Obj is T).Select(item => (T)item.Obj).FirstOrDefault();
        }

        private class CustomContainerItem<IType, CType>
            where IType : notnull
            where CType : IType, new()
        {
            public IType Obj { get; set; } = new CType();
        }

    }
}
