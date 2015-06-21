#include <cstring>
#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;

int jump[100001][17];
int a[100001];

int main() {
    int t, p, q, x, y, k, command;

    cin >> t;
    for (auto tt = 0; tt < t; ++tt)
    {
        memset(jump,0,sizeof(jump));
        memset(a,0,sizeof(a));
        cin >> p;
        for (auto pp = 0; pp < p; ++pp)
        {
            cin >> x >> y;
            a[pp] = x;
            jump[x][0] = y;
        }
        
        // when p == 100000, log2p = 17, because 2^17 > 100000 and 2^16 < 100000.
        auto log2p = (size_t)(log(p)/log(2)) + 1;
        for (size_t i = 1; i < log2p; ++i)
        {
            for (auto j = 0; j < p; ++j)
            {
                jump[a[j]][i] = jump[jump[a[j]][i-1]][i-1];
            }
        }
        
        cin >> q;
        for (auto qq = 0; qq < q; ++qq)
        {
            cin >> command;
            switch (command)
            {
                case 0:
                    cin >> y >> x;
                    jump[x][0] = y;
                    for (size_t i = 1; i < log2p; ++i)
                    {
                        jump[x][i] = jump[jump[x][i-1]][i-1];
                    }
                    break;
                case 1:
                    cin >> x;
                    for (size_t i = 0; i < log2p; ++i)
                    {
                        jump[x][i] = 0;
                    }
                    break;
                case 2:
                    cin >> x >> k;
                    auto j = 0;
                    while (x > 0 && k > 0)
                    {
                        if (k & 1)
                        {
                            x = jump[x][j];
                        }
                        k >>= 1;
                        j++;
                    }
                    cout << x << endl;
                    break;
            }
        }
    }
        
    return 0;
}
