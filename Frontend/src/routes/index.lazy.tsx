import { createLazyFileRoute } from '@tanstack/react-router'
import AdvertGallery from '../components/AdvertGallery'

export const Route = createLazyFileRoute('/')({
    component: AdvertGallery,
})

