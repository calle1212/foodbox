import {
    useQuery,
} from '@tanstack/react-query'
import { Post } from '../types';
import AdvertCard from './AdvertCard';
import { useUser } from '@clerk/clerk-react';
import { useEffect, useState } from 'react';
import PostDealForm from './PostDealForm';



export default function AdvertGallery() {

    const { user } = useUser();
    


    useEffect(() => {
        if (user) {
            const postUserToBackend = async () => {
                const userData = {
                    clerkId: user.id,
                    name: user.username
                };

                const response = await fetch('http://localhost:5063/api/users', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(userData),
                });

                if (!response.ok) {
                    console.error('Failed to send user data to backend:', response.statusText);
                }
            };

            postUserToBackend();
            console.log("ran PostUserToBackend");
        }
    }, [user]);



    //const sectionProps: sectionProps = { salties: data.salties }
    const { isPending, error, data, isFetching } = useQuery<Post[]>({
        queryKey: ["repoData"],
        queryFn: async () => {
            const response = await fetch(
                'http://localhost:5063/api/Posts',
            )
            return await response.json()
        },
    })

    if (isPending) return 'Loading...';
    if (error) return 'An error has occurred: ' + error.message
    if (isFetching) return "is fetching...";


    return (
        <>
            <div className='flex flex-wrap gap-4 justify-center p-5 '>
                {data.filter(post => post.isFulfilled == false && post.isAborted == false).map(post => <AdvertCard {...post} key={post.creatorClerkId} />)}
            </div>
            <div className='flex justify-center'>
                <details className='flex justify-center w-72' >
                    <summary className={`btn`} >Post a deal!</summary>
                    <PostDealForm />
                </details>
            </div>
        </>
    )
}