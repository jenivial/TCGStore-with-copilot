import Link from 'next/link';
import React from 'react';

const HomePage = () => {
    return (
        <section className="page">
            <div>
                <p className="eyebrow">Welcome</p>
                <h1>TCGStore vertical slices</h1>
                <p className="subtle">
                    Each slice owns its UI, domain, handlers, and persistence. The cards
                    slice demonstrates how the frontend calls the .NET cards endpoints.
                </p>
            </div>
            <div className="callout">
                <p>Explore the live data pulled from the backend:</p>
                <Link className="btn" href="/cards">
                    Browse cards
                </Link>
            </div>
        </section>
    );
};

export default HomePage;