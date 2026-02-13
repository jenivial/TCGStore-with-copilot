import './globals.css';
import Link from 'next/link';
import { Fraunces, Space_Grotesk } from 'next/font/google';
import React from 'react';

const fraunces = Fraunces({ subsets: ['latin'], variable: '--font-display' });
const spaceGrotesk = Space_Grotesk({ subsets: ['latin'], variable: '--font-body' });

const Layout = ({ children }: { children: React.ReactNode }) => {
    return (
        <html lang="en" className={`${fraunces.variable} ${spaceGrotesk.variable}`}>
            <body>
                <header className="header">
                    <div className="brand">
                        <span>TCG Store</span>
                        <strong>Vertical Slices</strong>
                    </div>
                    <nav className="nav">
                        <Link className="btn btn--ghost" href="/">
                            Home
                        </Link>
                        <Link className="btn" href="/cards">
                            Cards
                        </Link>
                    </nav>
                </header>
                <main>{children}</main>
                <footer className="footer">
                    <p>TCGStore Frontend · Next.js Vertical Slices</p>
                </footer>
            </body>
        </html>
    );
};

export default Layout;