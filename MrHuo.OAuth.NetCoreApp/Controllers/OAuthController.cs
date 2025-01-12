﻿using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MrHuo.OAuth.Huawei;
using MrHuo.OAuth.Wechat;
using MrHuo.OAuth.Gitlab;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MrHuo.OAuth.Baidu;
using Microsoft.AspNetCore.Http;
using MrHuo.OAuth.Gitee;
using MrHuo.OAuth.Github;
using MrHuo.OAuth.Coding;
using MrHuo.OAuth.SinaWeibo;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using MrHuo.OAuth.Alipay;
using MrHuo.OAuth.QQ;
using MrHuo.OAuth.OSChina;
using MrHuo.OAuth.DouYin;

namespace MrHuo.OAuth.NetCoreApp.Controllers
{
    public class OAuthController : Controller
    {
        [HttpGet("oauth/{type}")]
        public IActionResult Index(
            string type,
            [FromServices] BaiduOAuth baiduOAuth,
            [FromServices] WechatOAuth wechatOAuth,
            [FromServices] GitlabOAuth gitlabOAuth,
            [FromServices] GiteeOAuth giteeOAuth,
            [FromServices] GithubOAuth githubOAuth,
            [FromServices] HuaweiOAuth huaweiOAuth,
            [FromServices] CodingOAuth codingOAuth,
            [FromServices] SinaWeiboOAuth sinaWeiboOAuth,
            [FromServices] AlipayOAuth alipayOAuth,
            [FromServices] QQOAuth qqOAuth,
            [FromServices] OSChinaOAuth oschinaOAuth,
            [FromServices] DouYinOAuth douYinOAuth
        )
        {
            var redirectUrl = "";
            switch (type.ToLower())
            {
                case "baidu":
                    {
                        redirectUrl = baiduOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "wechat":
                    {
                        redirectUrl = wechatOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "gitlab":
                    {
                        redirectUrl = gitlabOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "gitee":
                    {
                        redirectUrl = giteeOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "github":
                    {
                        redirectUrl = githubOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "huawei":
                    {
                        redirectUrl = huaweiOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "coding":
                    {
                        redirectUrl = codingOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "sinaweibo":
                    {
                        redirectUrl = sinaWeiboOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "alipay":
                    {
                        redirectUrl = alipayOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "qq":
                    {
                        redirectUrl = qqOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "oschina":
                    {
                        redirectUrl = oschinaOAuth.GetAuthorizeUrl();
                        break;
                    }
                case "douyin":
                    {
                        redirectUrl = douYinOAuth.GetAuthorizeUrl();
                        break;
                    }
                default:
                    return ReturnToError($"没有实现【{type}】登录方式！");
            }
            return Redirect(redirectUrl);
        }

        [HttpGet("oauth/{type}callback")]
        public async Task<IActionResult> LoginCallback(
            string type,
            [FromServices] BaiduOAuth baiduOAuth,
            [FromServices] WechatOAuth wechatOAuth,
            [FromServices] GitlabOAuth gitlabOAuth,
            [FromServices] GiteeOAuth giteeOAuth,
            [FromServices] GithubOAuth githubOAuth,
            [FromServices] HuaweiOAuth huaweiOAuth,
            [FromServices] CodingOAuth codingOAuth,
            [FromServices] SinaWeiboOAuth sinaWeiboOAuth,
            [FromServices] AlipayOAuth alipayOAuth,
            [FromServices] QQOAuth qqOAuth,
            [FromServices] OSChinaOAuth oschinaOAuth,
            [FromServices] DouYinOAuth douYinOAuth,
            [FromQuery] string code,
            [FromQuery] string state,
            [FromQuery] string error_description = "")
        {
            Console.WriteLine($"LoginCallback [{HttpContext.Request.Path}]");
            try
            {
                if (!string.IsNullOrEmpty(error_description))
                {
                    throw new Exception(error_description);
                }
                HttpContext.Session.SetString("OAuthPlatform", type.ToLower());
                switch (type.ToLower())
                {
                    case "baidu":
                        {
                            var authorizeResult = await baiduOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "wechat":
                        {
                            var authorizeResult = await wechatOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "gitlab":
                        {
                            var authorizeResult = await gitlabOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "gitee":
                        {
                            var authorizeResult = await giteeOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "github":
                        {
                            var authorizeResult = await githubOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "huawei":
                        {
                            var authorizeResult = await huaweiOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "coding":
                        {
                            var authorizeResult = await codingOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "sinaweibo":
                        {
                            var authorizeResult = await sinaWeiboOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "alipay":
                        {
                            code = HttpContext.Request.Query["auth_code"];
                            var authorizeResult = await alipayOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "qq":
                        {
                            var authorizeResult = await qqOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "oschina":
                        {
                            var authorizeResult = await oschinaOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    case "douyin":
                        {
                            var authorizeResult = await douYinOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            HttpContext.Session.Set("OAuthUser", authorizeResult.UserInfo.ToUserInfoBase());
                            HttpContext.Session.Set("OAuthUserDetail", authorizeResult.UserInfo, true);
                            break;
                        }
                    default:
                        throw new Exception($"没有实现【{type}】登录回调！");
                }
                return RedirectToAction("Result");
            }
            catch (Exception ex)
            {
                HttpContext.Session.Remove("OAuthPlatform");
                HttpContext.Session.Remove("OAuthUser");
                HttpContext.Session.Remove("OAuthUserDetail");
                Console.WriteLine(ex.ToString());
                return ReturnToError(ex.Message);
            }
        }

        public IActionResult Result()
        {
            var oauthPlatform = HttpContext.Session.GetString("OAuthPlatform");
            var userInfo = HttpContext.Session.GetString("OAuthUser");
            var userInfoDetail = HttpContext.Session.GetString("OAuthUserDetail");
            if (string.IsNullOrEmpty(oauthPlatform) || string.IsNullOrEmpty(userInfoDetail))
            {
                return ReturnToError("OAuth授权失败！");
            }
            ViewBag.OAuthPlatform = oauthPlatform;
            ViewBag.OAuthUser = JsonSerializer.Deserialize<UserInfoBase>(userInfo);
            ViewBag.OAuthUserDetail = userInfoDetail;
            return View();
        }

        private IActionResult ReturnToError(string error)
        {
            return RedirectToAction("Error", "Home", new { error });
        }
    }
}
