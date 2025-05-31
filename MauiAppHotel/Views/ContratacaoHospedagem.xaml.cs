using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // Carregar lista de quartos no Picker
        List<Quarto> quartos = new List<Quarto>
        {
            new Quarto { Descricao = "Suíte Luxo", ValorDiariaAdulto = 200, ValorDiariaCrianca = 100 },
            new Quarto { Descricao = "Suíte Simples", ValorDiariaAdulto = 150, ValorDiariaCrianca = 80 },
            new Quarto { Descricao = "Suíte Família", ValorDiariaAdulto = 250, ValorDiariaCrianca = 120 }
        };

        pck_quarto.ItemsSource = quartos;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date,
            };

            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime data_selecionada_checkin = e.NewDate;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Sobre");
    }

}
