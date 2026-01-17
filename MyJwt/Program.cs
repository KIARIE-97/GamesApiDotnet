//define header
using System.Security.Cryptography;
using System.Text.Json;

var header = new
{
    alg = "HS256",
    typ = "JWT"
};

var payload = new
{
    userId = "1",
    email = "user@gmail.com",
    role = "Mentor",
    exp = DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds()
};

//convert to json
string headerJson = JsonSerializer.Serialize(header);
string payloadJson = JsonSerializer.Serialize(payload);

//encode to base64URL
//helper function
static string ToBase64UrlEncode (string data)
{
    var bytes =System.Text.Encoding.UTF8.GetBytes(data);
    return Convert.ToBase64String(bytes)
                .Replace("+", "-")
                .Replace("/", "_")
                .Replace("=", ""); 
}
string encodedHeader = ToBase64UrlEncode(headerJson);
string encodedPayload = ToBase64UrlEncode(payloadJson);

//creatig the signature
string secretKey = "I_AM_GETTING_THE_HANG_OF_IT";

//sign header and payload
static string CreateSignature(string data, string secret)
{
    var keyBytes = System.Text.Encoding.UTF8.GetBytes(secret);
    var dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
    
    using var hmac = new HMACSHA256(keyBytes);
    var hash = hmac.ComputeHash(dataBytes);
    return Convert.ToBase64String(hash)
                .Replace("+", "-")
                .Replace("/", "_")
                .Replace("=", ""); 

}
//generate signature
string unsignedToken = $"{encodedHeader}.{encodedPayload}";
string signature = CreateSignature(unsignedToken, secretKey);

string myJwt = $"{unsignedToken}.{signature}";

// Console.WriteLine("my Json web Token" + myJwt);

//token validation
var parts = myJwt.Split('.');
string data = $"{parts[0]}.{parts[1]}";
string exSign = CreateSignature(data, secretKey);

if(exSign != signature)
{
Console.WriteLine("Invalid token");
} else
{
    Console.WriteLine("hey ure logged in");
}
string payloadDecode = System.Text.Encoding.UTF8.GetString(
    Convert.FromBase64String(parts[1].Replace("-", "+").Replace("_", "/"))
);
var payloadData = JsonSerializer.Deserialize<Dictionary<string, object>>(payloadDecode);
long exp = Convert.ToInt64(payloadData["exp"]);
if(DateTimeOffset.UtcNow.ToUnixTimeSeconds() > exp)
{
    Console.WriteLine("Token expired");
}