using Avvir.Middleware.Core.DBContext;
using Avvir.Middleware.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avvir.Middleware.Core.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("Test")]
        public async Task<IActionResult> Test()
        {
            byte[] AttachmentBody = System.IO.File.ReadAllBytes("c:\\temp\\test.txt");
            using (AvvirDbContext dbContext = new AvvirDbContext())
            {
                
                List<Microsoft.Data.SqlClient.SqlParameter> param = new List<Microsoft.Data.SqlClient.SqlParameter>();
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@MessageGUID", Guid.NewGuid()));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@MimeType", "text"));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@Filename", "test.txt"));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@AttachmentBody", AttachmentBody));

                dbContext.Database.ExecuteSqlRaw(@"SaveFile @MessageGUID,
                                                            @MimeType,
                                                            @Filename,
                                                            @AttachmentBody", param.ToArray());
            }

            return Ok(new Response { Status = "Success", Message = "Test successfully!" });
        }

        [HttpPost]
        [Route("SaveComment")]
        public async Task<IActionResult> SaveComment(Guid AuthorGUID, string MessageGUID, string CommentBody)
        {
            using (AvvirDbContext dbContext = new AvvirDbContext())
            {
                List<Microsoft.Data.SqlClient.SqlParameter> param = new List<Microsoft.Data.SqlClient.SqlParameter>();
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@AuthorGUID", AuthorGUID));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@MessageGUID", MessageGUID));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@CommentBody", CommentBody));

                dbContext.Database.ExecuteSqlRaw(@"SaveComment @AuthorGUID,
                                                               @MessageGUID,
                                                               @CommentBody", param.ToArray());
            }

            return Ok(new Response { Status = "Success", Message = "Test successfully!" });
        }

        [HttpPost]
        [Route("SaveContactListRequest")]
        public async Task<IActionResult> SaveContactListRequest(Guid SenderGUID, Guid ReceiverGUID)
        {
            using (AvvirDbContext dbContext = new AvvirDbContext())
            {
                List<Microsoft.Data.SqlClient.SqlParameter> param = new List<Microsoft.Data.SqlClient.SqlParameter>();
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@SenderGUID", @SenderGUID));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@ReceiverGUID", ReceiverGUID));

                dbContext.Database.ExecuteSqlRaw(@"SaveContactListRequest @SenderGUID,
                                                                          @ReceiverGUID", param.ToArray());
            }

            return Ok(new Response { Status = "Success", Message = "Test successfully!" });
        }

        [HttpPost]
        [Route("SaveFile")]
        public async Task<IActionResult> SaveFile(Guid MessageGUID, string MimeType, string Filename, byte[] AttachmentBody)
        {
            using (AvvirDbContext dbContext = new AvvirDbContext())
            {
                List<Microsoft.Data.SqlClient.SqlParameter> param = new List<Microsoft.Data.SqlClient.SqlParameter>();
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@MessageGUID", MessageGUID));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@MimeType", MimeType));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@Filename", Filename));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@AttachmentBody", AttachmentBody));

                dbContext.Database.ExecuteSqlRaw(@"SaveFile @MessageGUID,
                                                            @MimeType,
                                                            @Filename,
                                                            @AttachmentBody", param.ToArray());
            }

            return Ok(new Response { Status = "Success", Message = "Test successfully!" });
        }

        [HttpPost]
        [Route("SaveMessage")]
        public async Task<IActionResult> SaveMessage(Guid AuthorGUID, Guid ReceiverGUID, Guid GroupGUID, Guid ReplyMessageGUID, string MessageBody)
        {
            using (AvvirDbContext dbContext = new AvvirDbContext())
            {
                List<Microsoft.Data.SqlClient.SqlParameter> param = new List<Microsoft.Data.SqlClient.SqlParameter>();
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@AuthorGUID", AuthorGUID));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@ReceiverGUID", ReceiverGUID));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@GroupGUID", GroupGUID));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@ReplyMessageGUID", ReplyMessageGUID));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@MessageBody", MessageBody));

                dbContext.Database.ExecuteSqlRaw(@"SaveMessage @AuthorGUID,
                                                               @ReceiverGUID,
                                                               @GroupGUID,
                                                               @ReplyMessageGUID,
                                                               @MessageBody", param.ToArray());
            }

            return Ok(new Response { Status = "Success", Message = "Test successfully!" });
        }

        [HttpPost]
        [Route("UpdateContactListRequest")]
        public async Task<IActionResult> UpdateContactListRequest(Guid RequestGUID, int NewStatus)
        {
            using (AvvirDbContext dbContext = new AvvirDbContext())
            {
                List<Microsoft.Data.SqlClient.SqlParameter> param = new List<Microsoft.Data.SqlClient.SqlParameter>();
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@RequestGUID", RequestGUID));
                param.Add(new Microsoft.Data.SqlClient.SqlParameter("@NewStatus", NewStatus));

                dbContext.Database.ExecuteSqlRaw(@"UpdateContactListRequest @RequestGUID,
                                                                            @NewStatus", param.ToArray());
            }

            return Ok(new Response { Status = "Success", Message = "Test successfully!" });
        }
    }
}
