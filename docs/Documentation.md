# Thumbnail genaration

Explanation of thumbnails generation (full sample [ https://elfinder.codeplex.com/SourceControl/latest]( https://elfinder.codeplex.com/SourceControl/latest)):
1) Add new routing path. Example:
{code: c#}
routes.MapRoute(null, "Thumbnails/{tmb}", new { controller = "Files", action = "Thumbs", tmb = UrlParameter.Optional });
{code: c#}

2) Add action to your controller with following code: 
{code: c#}
 public ActionResult Thumbs(string tmb)
 {
     return Connector.GetThumbnail(Request, Response, tmb);
 }
{code: c#}

3) Set property ThumbnailsUrl in your roots:
{code: c#}
ThumbnailsUrl = "Thumbnails/"
{code: c#}

4) Set directrory for store thumbnails. Thumbnails can be stored separately from original directory.
{code: c#}
ThumbnailsStorage = new DirectoryInfo(Server.MapPath("~/Files"));
{code: c#}

If your not set this property, than thumbnails will be generated "on fly" for every client's request and stored in client browser cache. Be carefull with this option because it can affect pefromance.

