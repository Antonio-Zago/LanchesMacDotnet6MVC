using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMacDotnet6MVC.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }

        [StringLength(100, MinimumLength =5, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome do lanche")]
        [Display(Name = "Nome")]
        public string LancheNome { get; set; }

        [Required(ErrorMessage = "Informe a descrição do lanche")]
        [Display(Name = "Descrição curta")]
        [MaxLength(100)]
        [MinLength(10)]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "Informe a descrição do lanche")]
        [Display(Name = "Descrição")]
        [MaxLength(500)]
        [MinLength(20)]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99)]
        public decimal Preco { get; set; }

        [Display(Name = "Imagem")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Thumbnail")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque?")]
        public bool EmEstoque { get; set; }

        //Para definir o relacionamento
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
