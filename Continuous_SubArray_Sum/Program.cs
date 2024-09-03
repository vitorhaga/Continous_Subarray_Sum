class Program()
{
    static void Main()
    {
        string? input;
        bool result;
        do
        {
            Console.WriteLine("Digite o array de inteiros apenas números e vírguals (Ex: 1,2,3,4,5): (Para sair digite '.')");
            input = Console.ReadLine();
            
            if (input == null)
                Console.WriteLine("O Array de inteiros não foi digitado!\n");
            else 
            if(!input.Contains('.'))
            {
                if (!input.Contains(',') && input.Length > 1)
                    Console.WriteLine("O Array de inteiros foi digitado incorretamente!\n");
                else
                {
                    var arrayNums = input.Split(',');
                    if (arrayNums.Length > 1)
                    {
                        List<int> listNums = [];
                        foreach (var stringNum in arrayNums)
                        {
                            bool validInt = int.TryParse(stringNum.Trim(), out int num);
                            if (validInt)
                            {
                                listNums.Add(num);
                            }
                        }

                        if (arrayNums.Length > listNums.Count)
                            Console.WriteLine("Não foram digitados apenas números e vírgulas!\n");
                        else
                        {
                            Console.WriteLine("Digite um número inteiro 'k': ");
                            var k = Console.ReadLine();
                            int num;
                            bool validInt = int.TryParse(k, out num);
                            if (validInt)
                            {
                                result = CheckSubarraySum(listNums.ToArray(), num);
                                Console.WriteLine("Entrada: nums = "+"{"+$"{input}"+"}"+$", k = {k}");
                                Console.WriteLine($"Saída: {result}\n");
                            }
                            else
                                Console.WriteLine("Não foi digitado um inteiro! \n");
                        }
                    }
                    else
                        Console.WriteLine("O Array de inteiros foi digitado incorretamente!\n");
                }
                Console.WriteLine("Pressione ENTER para continuar ou '.' para sair!");
                input = Console.ReadLine();

                if (input is not null && !input.Contains('.'))
                    Console.Clear();
            }
        } while (input != ".");
    }
    static bool CheckSubarraySum(int[] nums, int k)
    {
        Dictionary<int, int> remainders = new()
        {
            [0] = -1
        };
        int cumulativeSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            cumulativeSum += nums[i];
            int remainder = cumulativeSum % k;

            if (remainders.ContainsKey(remainder))
            {
                if (i - remainders[remainder] > 1)
                {
                    return true;
                }
            }
            else
            {
                remainders[remainder] = i;
            }
        }

        return false;
    }
}
