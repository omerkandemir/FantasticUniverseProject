using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;
using NLayer.Entities.Concretes;

namespace test
{
    public partial class Form1 : Form
    {
        private IAbilityService _abilityService;
        public Form1()
        {
            _abilityService = InstanceFactory.GetInstance<IAbilityService>();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //_abilityService.Add(new Ability
                //{
                //    Name = textBox1.Text,
                //});
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
