using Hjson;

namespace TheGrotto.Utilities {
    public partial class Utils {
        public static JsonValue GetJSONFromFile(string filePath) {
            Stream jsonStream = ModContent.GetInstance<TheGrotto>().GetFileStream(filePath);
            JsonValue jsonData = JsonValue.Load(jsonStream);
            jsonStream.Close();

            return jsonData;
        }
    }
}
