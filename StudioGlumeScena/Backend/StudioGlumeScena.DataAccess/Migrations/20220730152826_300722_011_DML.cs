using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _300722_011_DML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"UPDATE dbo.Lokacija SET MapaSource = 'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2833.845729210405!2d20.442479415404595!3d44.74316407909902!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x475a71998a42df29%3A0x8e4d33a7790858c2!2sCultural%20and%20Educational%20Centre%20Rakovica!5e0!3m2!1sen!2sgr!4v1659017168067!5m2!1sen!2sgr' WHERE Naziv LIKE 'Kulturni centar Rakovica'
                        UPDATE dbo.Lokacija SET MapaSource = 'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2829.0431954988053!2d20.40990942599765!3d44.84105366782122!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x475a65a66302e76d%3A0x5ca6ca2c68bcfefa!2sGradski%20park%202%2C%20Beograd%2C%20Serbia!5e0!3m2!1sen!2sgr!4v1659017416659!5m2!1sen!2sgr' WHERE Naziv LIKE 'Kulturno-sportski centar Pinki'
                        UPDATE dbo.Lokacija SET MapaSource = 'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2831.8073616340735!2d20.485828828996244!3d44.784732512246066!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x475a7089f523a527%3A0xd61e0c296b38d68f!2s%C5%A0umice%20Sports%20Center%2C%20Ustani%C4%8Dka%20125%2F1%2C%20Beograd%2C%20Serbia!5e0!3m2!1sen!2sgr!4v1659017468242!5m2!1sen!2sgr' WHERE Naziv LIKE N'Sportski centar Šumice'";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"UPDATE dbo.Lokacija SET MapaSource = NULL";

            migrationBuilder.Sql(sql);
        }
    }
}
