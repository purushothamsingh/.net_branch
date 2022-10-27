using JWT_AUTH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;  

namespace JWT_AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private static Response response =  new Response();

        private readonly JWT_Context db;

       public RegisterController(JWT_Context _db)
        {
            db = _db;
        }










        [HttpPost]

        public async Task<ActionResult<Register>> RegisterUser( Register request) {


            using(var hmac = new HMACSHA512())
            {
                Db_Registers registers = new Db_Registers();

                registers.IsRegister = true;
                registers.UserName = request.UserName;
                registers.PaswordSalt = hmac.Key;
                registers.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
                registers.Role = request.Role;
                registers.Email = request.Email;
                db.Db_Registers.Add(registers);
                db.SaveChanges();


                response.Message = "user register Successfully";
                response.Code = Microsoft.AspNetCore.Http.StatusCodes.Status200OK;
                response.data = registers;
                response.Error = null;
                return Ok(response);
                
            }
          
        
        }


        [HttpPost]
        [Route("login")]

        public async Task<ActionResult> Login(Login req)
        {
            var username = db.Db_Registers.Select(x => x.UserName == req.UserName);

            bool b = false;

         foreach(var reg in username)
            {
                if (reg)
                {
                    b = reg;
                }
               
            }

            if(b)
            {
                var has = db.Db_Registers.Where(x => x.UserName == req.UserName).Select(x => x.PaswordSalt);
                var hashed = db.Db_Registers.Where(x=>x.UserName == req.UserName).Select(x => x.PasswordHash);
                var n = has;
                byte[] salt = new byte[34];
                foreach(var i in has)
                {
                    salt = i;
                }
                using(var hmac = new HMACSHA512(salt))
                {

                    var myhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(req.Password));
                    var hashedone = db.Db_Registers.Where(x => x.UserName == req.UserName).Select(x => x.PasswordHash);

                    byte[] databasehash = new byte[2];
                    foreach(var i in hashedone)
                    {
                        databasehash = i;
                    }
                   if(myhash.SequenceEqual(databasehash))
                    {
                        Register rs = new Register();
                        string token = CreateToken( req);

                        return Ok(token);
                    }


                }
                return Ok("rd");

              
            }
            else
            {

                response.Message = "User Not found";
                response.Code = Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound;
                response.data = "0";
                response.Error = "Invalid Credentials";
                return Ok(response);
            }
          
        }

        private string CreateToken(Login req)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim (ClaimTypes.Name,req.UserName),
               // new Claim (ClaimTypes.Email,req.Email)
               
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("mytoken idkaldkhodsildbjafso"));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims:claims,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials:cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
             

        }
    }
}
