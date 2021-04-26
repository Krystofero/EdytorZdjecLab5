# EdytorZdjecLab5

Edytor zdjęć napisany w języku C# w środowiku Visual Studio.
Dostępne opcje: 
-przyciemnianie / rozjaśnianie zdjęcia
-negatyw zdjęcia
-16 algorytmów pozwalających na mieszanie ze sobą dwóch zdjęć

Aby włączyć program wystarczy otworzyć plik WindowsFormsApplication12.exe z folderu WindowsFormsApplication12/bin/Debug/

Pliki: Edytor.Designer.cs (pierwsze okno) oraz MieszanieObrazow.Designer.cs (drugie okno) tworzoną dwa interfejsy GUI za pomocą Projektanta formularzy systemu Windows.
Pliki: Edytor.cs oraz MieszanieObrazow.cs zawierają kod opisujący funkcję wywoływane dla poszczególnych komponentów składających się na GUI.

W chwili otwarcia programu ukazuje nam się pierwsze okno interfejsu. Zawiera ono dwa PictureBox'y (pierwszy to obraz wejściowy a drugi wyjściowy).
PictureBoxy automatycznie dopasowują swój rozmiar do paneli w których się znajdują po wczytaniu zdjęcia.(Dzięki właściwości SizeMode = AutoSize)
Wczytujemy dowolny plik png. lub jpg.(klikając przycisk wczytaj otwiera się openFileDialog). 
Następnie możemy go rozjaśniać lub przyciemniać wpisując wcześniej odpowiednie wartości w pola textBox oraz wywołać negatyw obrazu.
Przycisk kopiuj pozwala przenieś obraz wynikowy  na obraz wejściowy dzięki czemu możemy go dalej edytować.
Przycisk zapisz pozwala zapisać plik wynikowy o nazwie wpisanej w textBox (wcześniej należy zmienić ścieżkę docelową na odpowiednią dla naszego urządzenia)

        private void button12_Click(object sender, EventArgs e)
        {
            if(pictureBox2.Image != null)
            {
                pictureBox2.Image.Save("C:\\Users\\krzys\\OneDrive\\Obrazy\\JPG\\"+ textBox1.Text + "(zmienione).jpg", ImageFormat.Jpeg);
            }

Po wciśnięcie przycisku "Mieszanie" otwiera się drugie okno interfejsu. Tutaj mamy opcję wczytania dwóch plików wejściwych do PictureBox'ów.(Muszą być to zdjęcia o takich samych wymiarach)
Następnie możemy mieszać obrazy za pomocą jednego z 16 przycisków implementujących różne algorytmy mieszania (każdy skutkuje innym obrazem wyjściowym). 
Następnie możemy zapisać obraz wyjściowy tak jak robiliśmy to w oknie pierwszym interfejsu(czyli również należy zmienić ścieżkę docelową).

Wszystkie zaimplementowane w programie algorytmy bazują na Bitmapach zdjęć PictureBox'ów . Wczytują wartość koloru czerwonego/zielonego/niebieskiego każdego z pikseli zdjęcia/zdjęć wejściowych,
zmieniając w odpowiedni dla danego algorytmu sposób ich wartość i przypisując ją dla pikseli obrazu wyjściowego. Na koniec odświeżana jest zawartość wyjściowego pictureBox'a.
