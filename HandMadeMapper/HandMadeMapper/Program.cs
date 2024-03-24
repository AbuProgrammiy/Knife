using System.Reflection;            // PropertyInfo     |ishlashi uchun
using System.Text.Json;             // JsonSerializer   |ishlashi uchun

namespace HandMadeMapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserDTO userDTO = new UserDTO()
            {
                Name = "Abduxoliq",
                Email = "abdukholiq23@gmail.com",
            };

            User user = userDTO.Map<User>();
            Console.WriteLine(JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented=true}));
        }
    }

    public static class Mapper
    {
        public static T Map<T>(this object obj)
        {
            T Entity=Activator.CreateInstance<T>();     // T tipidan obyekt olish

            PropertyInfo[] properties = typeof(T).GetProperties();  // T tipini properitylarini olish

            foreach (PropertyInfo property in properties)
            {
                // obj ni propertiysi T ni propertysiga togri kelsa, uni Entityga valuesini o'zlashtirish
                PropertyInfo objecProperty=obj.GetType().GetProperty(property.Name)!;
                if (objecProperty != null)
                    property.SetValue(Entity, objecProperty.GetValue(obj));
            }
            return Entity;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class UserDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
