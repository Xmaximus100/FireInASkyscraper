import matplotlib.pyplot as plt
import numpy as n
from scipy import fft
from scipy.io.wavfile import write
import pandas as pan
from numpy import random


class Func_Gen:

    def __init__(self, freq=400.0, amp=2.0, b=5.0, s=10000):
        self.freq = freq
        self.amp = amp
        self.b = b
        self.s = s
        self.y = []
        self.t = n.linspace(0, self.b, int(self.s))

    def new_function(self, freq, amp, b, r):
        self.freq = freq
        self.amp = amp
        self.b = b
        self.s = r

    def new_noise(self, amp, b, r):
        self.amp = amp
        self.b = b
        self.s = r

    def sine(self):
        print(self.freq)
        f_sine = self.amp * n.sin(2 * n.pi * self.freq * self.t)
        return f_sine

    def square(self):
        f_sign = self.amp * n.sign(n.sin(2 * n.pi * self.freq * self.t))
        return f_sign

    def sawtooth(self):
        f_sawtooth = (-self.amp * 2/n.pi) * n.arctan(1/(n.tan(2 * n.pi * self.freq * self.t)))
        return f_sawtooth

    def triangle(self):
        f_triangle = (self.amp * 2)/n.pi * n.arcsin(n.sin(2 * n.pi * self.freq * self.t))
        return f_triangle

    def white_noise(self):
        noise = self.amp * n.random.rand(len(self.t))
        return noise

    def func_choice(self, x):
        if x == 1:
            self.y = self.sine()
        elif x == 2:
            self.y = self.square()
        elif x == 3:
            self.y = self.sawtooth()
        elif x == 4:
            self.y = self.triangle()
        elif x == 5:
            self.y = self.white_noise()

    def tranformata_fouriera(self):
        N = len(self.t)
        dt = self.t[1] - self.t[0]
        yf = 2.0 / N * n.abs(fft.fft(self.y)[0:N // 2])
        xf = n.fft.fftfreq(N, d=dt)[0:N // 2]
        return xf, yf

    def func_gen(self, x):
        if x == 1:
            plt.plot(self.t, self.y)
            plt.show()
        elif x == 2:
            a, b = self.tranformata_fouriera()
            plt.plot(a, b)
            # plt.xlim((self.freq*0.5), (self.freq*20))
            plt.show()

    def wav_save(self):
        scaled = n.int16(self.y * 32767)
        write('zadaniedomowe5.wav', 44100, scaled)

    def csv_save(self):
        x, data = self.tranformata_fouriera()
        df = pan.DataFrame({"t": x, "amp": data})
        df.to_csv("zadaniedomowe5.csv", index=False, sep='\t')


# print("Witamy w generatorze funkcji!\nPrzy pomocy tego niezawodnego programu możesz"
#       "stworzyć dowolną z wypisanych poniżej przebiegów:\n1) Sinusoidalny\n2) Prostokątny\n"
#       "3) Piłokształtny\n4) Trójkątny\n5) Biały szum\nWpisz cyfrę przypisaną do porządanego wykresu:\n")
#
# global a, f, x1, x2, s
# x = int(input())
# if x > 5 or x < 1:
#     print("Wprowadzona cyfra jest nieprawidłowa!")
#     quit()
# elif x == 5:
#     f = 440
#     a = float(input("Podaj amplitudę: "))
#     x1 = float(input("Minimalny zakres funkcji: "))
#     x2 = float(input("Maksymalny zakres funkcji: "))
#     s = int(input("Krok: "))
#     if x2 < x1:
#         print("Zły zakres!")
#         quit()
# else:
#     a = float(input("Podaj amplitudę: "))
#     f = float(input("Podaj częstotliwość: "))
#     x1 = float(input("Minimalny zakres funkcji: "))
#     x2 = float(input("Maksymalny zakres funkcji: "))
#     s = int(input("Krok: "))
#     if x2 < x1:
#         print("Zły zakres!")
#         quit()
# print(f)
# zmienna1 = Func_Gen(f, a, x1, x2, s)
# zmienna1.func_choice(x)
# print("Co chcesz zrobic teraz?\n1) Narysuj wykres funkcji\n2) Narysuj wykres transformaty Fouriera"
#       " podanej funkcji\n3) Zapisz przebieg czasowy do zadaniedomowe5.wav\n4) Zapisz transformate Fouriera do"
#       "zadaniedomowe5.csv")
# while True:
#     z = int(input())
#     if z == 1:
#         zmienna1.func_gen(1)
#     elif z == 2:
#         zmienna1.func_gen(2)
#     elif z == 3:
#         zmienna1.wav_save()
#         print("Zapisano do zadaniedomowe5.wav")
#     elif z == 4:
#         zmienna1.csv_save()
#         print("Zapisano do zadaniedomowe5.csv")
#     print('\nAby zakończyć program wpisz "0", możesz też wybrac inną opcję z listy: ')
#     if z == 0:
#         quit()
# zmienna1 = Func_Gen()
# zmienna1.new_function(2000, 20, 10, 100000)
# zmienna1.func_choice(3)
# zmienna1.func_gen(1)
# zmienna1.csv_save()

