namespace AyrLyne_Personal.Data
{
    public interface IGoogleSignInFormData
    {
        string clientID { get; set; }
        string credential { get; set; }
        string g_csrf_token { get; set; }
        string select_by { get; set; }
    }
}